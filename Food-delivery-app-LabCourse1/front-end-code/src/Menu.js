import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
import { AddMenuModal } from './AddMenuModal';
import { EditMenuModal } from './EditMenuModal';
import { Navigation } from './Navigation';


export class Menu extends Component {
    constructor(props) {
        super(props);
        this.state = { menute: [], addModalShow: false, editModalShow: false }
    }

    //marrja e te dhenave nga API
    refreshList() {
        fetch(process.env.REACT_APP_API + 'menu')
            .then(response => response.json())
            .then(data => {
                this.setState({ menute: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    //delete a restaurant
    deleteMenu(id) {
        if (window.confirm('A doni ta fshini menu-ne?')) {
            fetch(process.env.REACT_APP_API + 'menu/' + id, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
    }

    render() {
        const { menute, id, emertimi, nr_artikujve} = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });
        return (
            <div className="restoranti mt-5">
                <Navigation />
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Emertimi</th>
                            <th>Nr i Artikujve</th>
                        </tr>
                    </thead>
                    <tbody>
                        {menute.map(el =>
                            <tr key={el.id}>
                                <td>{el.id}</td>
                                <td>{el.emertimi}</td>
                                <td>{el.nr_artikujve}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={() => this.setState({
                                                editModalShow: true,
                                                id: el.id, emertimi: el.emertimi, nr_artikujve: el.nr_artikujve
                                            })}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                            onClick={() => this.deleteMenu(el.id)}>
                                            Delete
                                        </Button>

                                        <EditMenuModal show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            id={id}
                                            emertimi={emertimi}
                                            nr_artikujve={nr_artikujve} />
                                    </ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>
                <ButtonToolbar>
                    <div className="d-grid gap-2">
                        <Button variant='primary' size='lg'
                            onClick={() => { this.setState({ addModalShow: true }) }}>
                            Shto Menu
                        </Button>
                    </div>
                    <AddMenuModal show={this.state.addModalShow}
                        onHide={addModalClose}
                    />
                </ButtonToolbar>
            </div>
        )
    }
}