import React, { Component } from 'react';
import * as request from 'superagent';

export class Home extends Component {
    displayName = Home.name
    state = {
        orders: [],
        payments: []
    }

    componentDidMount() {
        this.getOrders();
        this.getPayments();
    }

    createOrder = () => {
        request.get("http://localhost:51107/api/orders/place")
            .then(res => {
                if (res.statusCode === 200) {
                    setTimeout(() => { this.getOrders(); }, 1000);
                    setTimeout(() => { this.getPayments(); }, 1200);
                }
            });
    }

    getPayments = () => {
        request.get("http://localhost:51066/api/payments/all")
            .then(res => {
                if (res.statusCode === 200) {
                    this.setState({ payments: JSON.parse(res.text) });
                }
            })
            .catch(console.error);
    }

    getOrders = () => {
        request.get("http://localhost:51107/api/orders/all")
            .then(res => {
                if (res.statusCode === 200) {
                    this.setState({ orders: JSON.parse(res.text) });
                }                
            })
            .catch(console.error);
    }

    cancelOrder = (id) => {
        request.get(`http://localhost:51107/api/orders/cancel?id=${id}`)
            .then(res => {
                if (res.statusCode === 200) {
                    setTimeout(() => { this.getOrders(); }, 1000);
                    setTimeout(() => { this.getPayments(); }, 1500);
                }
            })
            .catch(console.error);
    }

    renderOrderRows = (orders) => {
        return orders.map(order => {
            return (
                <tr key={order.aggregateId}>
                    <td>{order.aggregateId}</td>
                    <td>{order.itemCount}</td>
                    <td>{order.totalAmount}</td>
                    <td>{order.status === 0 ? "Placed" : "Cancelled"}</td>
                    <td><button onClick={() => this.cancelOrder(order.aggregateId)}>Cancel</button></td>
                </tr>
            );
        });
    }

    renderPaymentRows = (payments) => {
        return payments.map(payment => {
            return (
                <tr key={payment.orderId}>
                    <td>{payment.orderId}</td>
                    <td>{payment.amount}</td>
                    <td>{payment.status === 0 ? "Created" : payment.status === 1 ? "Processed" : "Refunded"}</td>
                </tr>
            );
        });
    }

    renderOrdersTable = () => {
        console.log(this.state.orders);
        if (this.state.orders.length === 0) return "No orders found";
        else
        return (
            <table className="table">
                <thead>
                    <tr>
                        <td>Order ID</td>
                        <td>Item Count</td>
                        <td>Amount</td>
                        <td>Status</td>
                        <td>Actions</td>
                    </tr>
                </thead>
                <tbody>
                    { this.renderOrderRows(this.state.orders) }
                </tbody>
            </table>
        );
    }

    renderPaymentsTable = () => {
        console.log(this.state.payments);
        if (this.state.payments.length === 0) return "No payments found";
        else
            return (
                <table className="table">
                    <thead>
                        <tr>
                            <td>Order ID</td>
                            <td>Amount</td>
                            <td>Status</td>
                        </tr>
                    </thead>
                    <tbody>
                        {this.renderPaymentRows(this.state.payments)}
                    </tbody>
                </table>
            );
    }

  render() {
    return (
      <div>
            <h1>NServiceBus with Microservices</h1>
            <button onClick={this.createOrder}>Create Order</button>
            <br />
            <h3>Orders</h3>
            {this.renderOrdersTable()}
            <br />
            <h3>Payments</h3>
            {this.renderPaymentsTable()}
      </div>
    );
  }
}
