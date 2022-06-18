
import React,{Component} from 'react';
import {Modal,Button, Row, Col, Form} from 'react-bootstrap';

export class AddQytetinModal extends Component{
    constructor(props){
        super(props);
        this.handleSubmit=this.handleSubmit.bind();
    }

    handleSubmit(event){
        event.preventDefault();
        fetch(process.env.REACT_APP_API+'qyteti',{
            method:'POST',
            headers:{
                'Accept':'application/json',
                'Content-Type':'application/json'
            },
            body:JSON.stringify({
                emri:event.target.emri.value
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
            Shto qytetin
        </Modal.Title>
    </Modal.Header>
    <Modal.Body>

        <Row>
            <Col sm={6}>
                <Form onSubmit={this.handleSubmit}>
                    <Form.Group controlId="emri">
                        <Form.Label>Emri qytetit</Form.Label>
                        <Form.Control type="text" name="emri" required 
                        placeholder="Emri qytetit"/>
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