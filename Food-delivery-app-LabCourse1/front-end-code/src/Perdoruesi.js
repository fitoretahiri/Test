import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
import { EditPerdoruesiModal } from './EditPerdoruesiModal';
import { Navigation } from './Navigation';


export class Perdoruesi extends Component {
    constructor(props) {
        super(props);
        this.state = { perdoruesit: [], addModalShow: false, editModalShow: false }
    }

    //marrja e te dhenave nga API
    refreshList() {
        fetch(process.env.REACT_APP_API + 'perdoruesi')
            .then(response => response.json())
            .then(data => {
                this.setState({ perdoruesit: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    //delete a restaurant
    deletePerdoruesin(id) {
        if (window.confirm('A doni ta fshini perdoruesin?')) {
            fetch(process.env.REACT_APP_API + 'perdoruesi/' + id, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
    }

    render() {
        const { perdoruesit, perdoruesiID, email, emri,password,adresa,nr_telefonit,photoProfile,roliID} = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });
        return (
            <div className="perdoruesi mt-5">
                <Navigation />
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>ID e perdoruesit</th>
                            <th>Email</th>
                            <th>Emri i plote</th>
                            <th>Password</th>
                            <th>Adresa</th>
                            <th>Numri i telefonit</th>
                            <th>Foto e profilit</th>
                            <th>Roli</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {perdoruesit.map(el =>
                            <tr key={el.perdoruesiID}>
                                <td>{el.perdoruesiID}</td>
                                <td>{el.email}</td>
                                <td>{el.emri}</td>
                                <td>{el.password}</td>
                                <td>{el.adresa}</td>
                                <td>{el.nr_telefonit}</td>
                                <td>{el.photoProfile}</td>
                                <td>{el.roli.role}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={() => this.setState({
                                                editModalShow: true,
                                                perdoruesiID: el.perdoruesiID, email: el.email, emri: el.emri, password: el.password, adresa: el.adresa, nr_telefonit: el.nr_telefonit, photoProfile: el.photoProfile
                                            })}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                            onClick={() => this.deletePerdoruesin(el.perdoruesiID)}>
                                            Delete
                                        </Button>

                                        <EditPerdoruesiModal show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            perdoruesiID={perdoruesiID}
                                            email={email}
                                            emri={emri}
                                            password={password}
                                            adresa={adresa}
                                            nr_telefonit={nr_telefonit}
                                            photoProfile={photoProfile}
                                        />
                                    </ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>
            </div>
        )
    }
}