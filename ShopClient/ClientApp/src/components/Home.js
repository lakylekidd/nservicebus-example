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

    getOrders = () => {
        request.get("http://localhost:51107/api/orders/all")
            .then(res => {
                console.log(res);
            })
            .catch(err => {
                return "No orders found";
            });
    }

    renderOrders = () => {
        if (this.state.orders.length === 0) return "No orders found";
        return (
            <table className="table">
                <th>
                    <tr>
                        <td>Order ID</td>
                        <td>Item Count</td>
                        <td>Amount</td>
                    </tr>
                </th>
            </table>
        );
    }

  render() {
    return (
      <div>
            <h1>NServiceBus with Microservices</h1>
            <button>Create Order</button>
            <br />
            { this.renderOrders() }
      </div>
    );
  }
}
