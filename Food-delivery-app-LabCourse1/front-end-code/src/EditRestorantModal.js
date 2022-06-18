import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditRestorantModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        console.log(event.target.id.value)
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'restoranti' ,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                id:event.target.id.value,
                emri:event.target.emri.value,
                qyteti:event.target.emri.value,
                adresa:event.target.adresa.value,
                nr_kontaktues:event.target.nr.value
            })
        })
        .then(res=>res.json())
        .then((result)=>{
            alert(result);
        },
        (error)=>{
            alert('Failed');
        })
    }
    render(){
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
            Edito Restorantin
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="id">
                        <Form.Label>Emri Restorantit</Form.Label>
                        <Form.Control type="text" name="id" required disabled
                        defaultValue={this.props.id}
                        placeholder="id"/>
                    </Form.Group>
                    <Form.Group controlId="emri">
                        <Form.Label>Emri Restorantit</Form.Label>
                        <Form.Control type="text" name="emri" required 
                        defaultValue={this.props.emri}
                        placeholder="emri"/>
                    </Form.Group>

                    <Form.Group controlId="qyteti">
                        <Form.Label>Qyteti Restorantit</Form.Label>
                        <Form.Control type="text" name="qyteti" required 
                        defaultValue={this.props.qyteti}
                        placeholder="qyteti"/>
                    </Form.Group>

                    <Form.Group controlId="adresa">
                        <Form.Label>Adresa Restorantit</Form.Label>
                        <Form.Control type="text" name="adresa" required 
                        defaultValue={this.props.adresa}
                        placeholder="adresa"/>
                    </Form.Group>

                    <Form.Group controlId="nr_kontaktues">
                        <Form.Label>Numri Restorantit</Form.Label>
                        <Form.Control type="text" name="nr" required 
                        defaultValue={this.props.nr_kontaktues}
                        placeholder="Numri Telefonit"/>
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