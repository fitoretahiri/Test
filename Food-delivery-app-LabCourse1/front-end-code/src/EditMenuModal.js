import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class EditMenuModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind(this);
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'menu' ,{
            method:'PUT',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                id:event.target.id.value,
                emertimi:event.target.emertimi.value,
                nr_artikujve:event.target.nr_artikujve.value
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
            Edito Menu-ne
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="id">
                        <Form.Label>Id</Form.Label>
                        <Form.Control type="text" name="id" required disabled
                        defaultValue={this.props.id}
                        placeholder="id"/>
                    </Form.Group>
                    <Form.Group controlId="emertimi">
                        <Form.Label>Emertimi</Form.Label>
                        <Form.Control type="text" name="emertimi" required 
                        defaultValue={this.props.emertimi}
                        placeholder="emertimi"/>
                    </Form.Group>
                    <Form.Group controlId="nr_artikujve">
                        <Form.Label>Nr i artikujve</Form.Label>
                        <Form.Control type="text" name="nr_artikujve" required 
                        defaultValue={this.props.nr_artikujve}
                        placeholder="nr_artikujve"/>
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