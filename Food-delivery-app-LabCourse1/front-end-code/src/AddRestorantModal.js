
import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class AddRestorantModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind();
    }

    handleSubmit(event){
        //const dt = new Date();
        //let date = dt.getFullYear()+'-'+(dt.getMonth()+1)+'-'+dt.getDate();
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'restoranti',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                emri:event.target.emri.value,
                qyteti:event.target.qyteti.value,
                adresa:event.target.adresa.value,
                nr_kontaktues:event.target.nr_kontaktues.value
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
       return(
           

           <div className="container">
               
<Modal
{...this.props}
size="lg"
aria-labelledby="contained-modal-title-vcenter"
centered
>
    <Modal.Header closeButton>
        <Modal.Title id="contained-modal-title-vcenter">
            Shto Restorantin
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="emri">
                        <Form.Label>Emri Restorantit</Form.Label>
                        <Form.Control type="text" name="emri" required 
                        placeholder="Emri Restorantit"/>
                    </Form.Group>
                    <Form.Group controlId="qyteti">
                        <Form.Label>Qyteti</Form.Label>
                        <Form.Control type="text" name="qyteti" required 
                        placeholder="Qyteti"/>
                    </Form.Group>
                    <Form.Group controlId="adresa">
                        <Form.Label>Adresa</Form.Label>
                        <Form.Control type="text" name="adresa" required 
                        placeholder="adresa"/>
                    </Form.Group>
                    <Form.Group controlId="nr_kontaktues">
                        <Form.Label>Numri</Form.Label>
                        <Form.Control type="text" name="nr_kontaktues" required 
                        placeholder="Nr Kontaktues"/>
                    </Form.Group>

                    <Form.Group>
                        <Button variant="primary" type="submit">
                            Shto
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