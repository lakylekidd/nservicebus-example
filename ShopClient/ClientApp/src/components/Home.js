import React, { Component } from 'react';
import * as request from 'superagent';

export class Home extends Component {
    displayName = Home.name
    state = {
        orders: []
    }

    componentDidMount() {
        this.getOrders();
    }

    createOrder = () => {
        request.get("http://localhost:51107/api/orders/place")
            .then(res => {
                if (res.statusCode === 200) {
                    setTimeout(() => { this.getOrders(); }, 2000);
                }
            });
    }

    getOrders = () => {
        request.get("http://localhost:51107/api/orders/all")
            .then(res => {
                if (res.statusCode === 200) {
                    //console.log(JSON.parse(res.text));
                    this.setState({ orders: JSON.parse(res.text) });
                }                
            })
            .catch(console.error);
    }

    cancelOrder = (id) => {
        request.get(`http://localhost:51107/api/orders/cancel?id=${id}`)
            .then(res => {
                if (res.statusCode === 200) {
                    console.log(JSON.parse(res.text));
                    this.getOrders();
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

    renderOrders = () => {
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

  render() {
    return (
      <div>
            <h1>NServiceBus with Microservices</h1>
            <button onClick={this.createOrder}>Create Order</button>
            <br />
            { this.renderOrders() }
      </div>
    );
  }
}
