import React, { Component } from 'react';
import { Table } from 'react-bootstrap';
import { Button, ButtonToolbar } from 'react-bootstrap';
import { AddRoleModal } from './AddRoleModal';
import { EditRoleModal } from './EditRoleModal';
import { Navigation } from './Navigation';


export class Roli extends Component {
    constructor(props) {
        super(props);
        this.state = { roles: [], addModalShow: false }
    }

    //marrja e te dhenave nga API
    refreshList() {
        fetch(process.env.REACT_APP_API + 'role')
            .then(response => response.json())
            .then(data => {
                this.setState({ roles: data });
            });
    }

    componentDidMount() {
        this.refreshList();
    }

    componentDidUpdate() {
        this.refreshList();
    }

    //delete a user
    deleteRole(id) {
        if (window.confirm('A doni ta fshini rolin?')) {
            fetch(process.env.REACT_APP_API + 'role/' + id, {
                method: 'DELETE',
                header: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                }
            })
        }
    }

    render() {
        const { roles, roliID, role } = this.state;
        let addModalClose = () => this.setState({ addModalShow: false });
        let editModalClose = () => this.setState({ editModalShow: false });
        return (
            <div className="role mt-5">
                <Navigation/>
                <Table className="mt-4" striped bordered hover size="sm">
                    <thead>
                        <tr>
                            <th>ID e rolit</th>
                            <th>Lloji i rolit</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                    <tbody>
                        {roles.map(el =>
                            <tr key={el.roliID}>
                                <td>{el.roliID}</td>
                                <td>{el.role}</td>
                                <td>
                                    <ButtonToolbar>
                                        <Button className="mr-2" variant="info"
                                            onClick={() => this.setState({
                                                editModalShow: true,
                                                roliID: el.roliID, role: el.role
                                            })}>
                                            Edit
                                        </Button>

                                        <Button className="mr-2" variant="danger"
                                            onClick={() => this.deleteRole(el.roliID)}>
                                            Delete
                                        </Button>

                                        <EditRoleModal show={this.state.editModalShow}
                                            onHide={editModalClose}
                                            roliID={roliID}
                                            role={role} />
                                    </ButtonToolbar>

                                </td>

                            </tr>)}
                    </tbody>

                </Table>
                <ButtonToolbar>
                    <div className="d-grid gap-2">
                        <Button variant='primary' size='lg'
                            onClick={() => { this.setState({ addModalShow: true }) }}>
                            Shto Rolin
                        </Button>
                    </div>
                    <AddRoleModal show={this.state.addModalShow}
                        onHide={addModalClose}
                    />
                </ButtonToolbar>
            </div>
        )
    }
}