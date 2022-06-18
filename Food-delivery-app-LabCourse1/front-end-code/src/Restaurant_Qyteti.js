import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
//import { AddQytetinModal } from './AddQytetinModal';
//import { EditQytetinModal } from './EditQytetinModal';
import { Navigation } from './Navigation';


export class Restaurant_Qyteti extends Component {
    constructor(props) {
        super(props);
        this.state = { lidhjet: [], addModalShow: false }
    }

    //marrja e te dhenave nga API
    refreshList() {
        fetch(process.env.REACT_APP_API + 'restaurant_qyteti')
            .then(response => response.json())
            .then(data => {
                this.setState({ lidhjet: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    deleteLidhja(id) {
        if (window.confirm('A doni ta fshini kete lokacion?')) {
            fetch(process.env.REACT_APP_API + 'restaurant_qyteti/' + id, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
    }

    render() {
        const { lidhjet, id, restaurantID, qytetiID } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });
        return (
            <div className="mt-5">
                <Navigation />
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Restauranti</th>
                            <th>Qyteti</th>
                        </tr>
                    </thead>
                    <tbody>
                        {lidhjet.map(el =>
                            <tr key={el.id}>
                                <td>{el.id}</td>
                                <td>{el.restaurantID}</td>
                                <td>{el.qytetiID}</td>
                                <td>

                                </td>
                            </tr>)}
                    </tbody>

                </Table>

            </div>
        )
    }
}