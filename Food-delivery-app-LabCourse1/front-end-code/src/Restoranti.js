import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
import { AddRestorantModal } from './AddRestorantModal';
import { EditRestorantModal } from './EditRestorantModal';
import { Navigation } from './Navigation';


export class Restoranti extends Component {
    constructor(props) {
        super(props);
        this.state = { restorantet: [], addModalShow: false, editModalShow: false }
    }

    //marrja e te dhenave nga API
    refreshList() {
        fetch(process.env.REACT_APP_API + 'restaurant')
            .then(response => response.json())
            .then(data => {
                this.setState({ restorantet: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    //delete a restaurant
    deleteRestorant(id) {
        if (window.confirm('A doni ta fshini restorantin?')) {
            fetch(process.env.REACT_APP_API + 'restaurant/' + id, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
    }

    render() {
        const { restorantet, id, emri, qyteti, adresa, nr_kontaktues } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });
        return (
            <div className="restaurant mt-5">
                <Navigation/>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Emri</th>
                            <th>Qyteti</th>
                            <th>Adresa</th>
                            <th>Nr.Kontaktues</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {restorantet.map(el =>
                            <tr key={el.id}>
                                <td>{el.emri}</td>
                                <td>{el.qyteti}</td>
                                <td>{el.adresa}</td>
                                <td>{el.nr_kontaktues}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={() => this.setState({
                                                editModalShow: true,
                                                id: el.id, emri: el.emri, qyteti: el.qyteti, adresa: el.adresa, nr_kontaktues: el.nr_kontaktues
                                            })}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                            onClick={() => this.deleteRestorant(el.id)}>
                                            Delete
                                        </Button>

                                        <EditRestorantModal show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            id={id}
                                            emri={emri}
                                            qyteti={qyteti}
                                            adresa={adresa}
                                            nr_kontaktues={nr_kontaktues} />
                                    </ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>
                <ButtonToolbar>
                    <div className="d-grid gap-2">
                        <Button variant='primary' size='lg'
                            onClick={() => { this.setState({ addModalShow: true }) }}>
                            Shto Restorantin
                        </Button>
                    </div>
                    <AddRestorantModal show={this.state.addModalShow}
                        onHide={addModalClose}
                    />
                </ButtonToolbar>
            </div>
        )
    }
}