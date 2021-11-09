import React, { Component } from 'react';
import { Form, Button } from 'react-bootstrap';

export class EditProduct extends Component {
    static displayName = EditProduct.name;

    constructor(props) {
        super(props);
        this.EditProduct = this.EditProduct.bind(this);
    }

    componentDidMount() {
    }

    EditProduct(e, product) {
        fetch("/EditProduct/", product)
    }

    render() {        
        return (
            <div>
            <Form>
                <Form.Group className="mb-3" controlId="formName">
                    <Form.Label>Name</Form.Label>
                    <Form.Control type="text" placeholder="Name" />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formProductNumber">
                    <Form.Label>Product Number</Form.Label>
                    <Form.Control type="text" placeholder="Product Number" />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formPrice">
                    <Form.Label>Price</Form.Label>
                    <Form.Control type="text" placeholder="Price" />
                </Form.Group>
                <Button variant="primary" type="submit" onClick={EditProduct}>
                    Submit
                </Button>
                </Form>
                </div>
            );
    }
}
