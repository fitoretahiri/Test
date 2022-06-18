import React, { Component } from 'react';
import { Modal, Button, Row, Col, Form } from 'react-bootstrap';

export class EditPerdoruesiModal extends Component {
    constructor(props) {
        super(props);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleSubmit(event) {
        console.log(event.target.id.value)
        event.preventDefault();
        fetch(process.env.REACT_APP_API + 'perdoruesi', {
            method: 'PUT',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                perdoruesiID: event.target.perdoruesiID.value,
                email: event.target.email.value,
                emri: event.target.emri.value,
                password: event.target.password.value,
                adresa: event.target.adresa.value,
                nr_telefonit: event.target.nr_telefonit.value,
                photoProfile: event.target.photoProfile.value,
                roli: event.target.roli.value
            })
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
            },
                (error) => {
                    alert('Failed');
                })
    }
    render() {
        return (
            <div className="container">

                <Modal
                    {...this.props}
                    size="lg"
                    aria-labelledby="contained-modal-title-vcenter"
                    centered
                >
                    <Modal.Header closeButton>
                        <Modal.Title id="contained-modal-title-vcenter">
                            Edito Perdoruesin
                        </Modal.Title>
                    </Modal.Header>
                    <Modal.Body>

                        <Row>
                            <Col sm={6}>
                                <Form onSubmit={this.handleSubmit}>
                                    <Form.Group controlId="perdoruesiID">
                                        <Form.Label>Email i perdoruesit</Form.Label>
                                        <Form.Control type="text" name="email" required
                                            defaultValue={this.props.email}
                                            placeholder="email" />
                                    </Form.Group>
                                    <Form.Group controlId="emri">
                                        <Form.Label>Emri Perdoruesit</Form.Label>
                                        <Form.Control type="text" name="emri" required
                                            defaultValue={this.props.emri}
                                            placeholder="emri" />
                                    </Form.Group>

                                    <Form.Group controlId="password">
                                        <Form.Label>Password</Form.Label>
                                        <Form.Control type="text" name="password" required disabled
                                            defaultValue={this.props.password}
                                            placeholder="password" />
                                    </Form.Group>

                                    <Form.Group controlId="adresa">
                                        <Form.Label>Adresa</Form.Label>
                                        <Form.Control type="text" name="adresa" required
                                            defaultValue={this.props.adresa}
                                            placeholder="adresa" />
                                    </Form.Group>

                                    <Form.Group controlId="nr_telefonit">
                                        <Form.Label>Numri i tel</Form.Label>
                                        <Form.Control type="text" name="nr_telefonit" required
                                            defaultValue={this.props.nr_telefonit}
                                            placeholder="Numri Telefonit" />
                                    </Form.Group>

                                    <Form.Group controlId="photoProfile">
                                        <Form.Label>Fotografia e profilit</Form.Label>
                                        <Form.Control type="text" name="photoProfile" required
                                            defaultValue={this.props.photoProfile}
                                            placeholder="Foto e profilit" />
                                    </Form.Group>
                                    <Form.Group>
                                        <Button variant="primary" type="submit">
                                            Update
                                        </Button>
                                    </Form.Group>
                                </Form>
                            </Col>
                        </Row>
                    </Modal.Body>

                    <Modal.Footer>
                        <Button variant="danger" onClick={this.props.onHide}>Close</Button>
                    </Modal.Footer>

                </Modal>

            </div>
        )
    }

}