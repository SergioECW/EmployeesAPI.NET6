import React, { Component } from 'react';
import { Button, Form } from 'react-bootstrap';
import { Link } from 'react-router-dom';

export class Product extends Component {
    static displayName = Product.name;

    constructor(props) {
        super(props);
        this.CreateProduct = this.CreateProduct.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.state = {
            id: '',
            name: '',
            productNumber: '',
            price: '',
        }
    }

    componentDidMount() {
    }

    CreateProduct(e) {
        e.preventDefault();
        fetch("/CreateProduct", {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({
                name: this.state.name,
                productName: this.state.productNumber,
                price: this.state.price
            })
        });
    }

    handleChange = (e) => {
        this.setState({ [e.target.name]: e.target.value });
    }

    render() {
        return (
            <div>
            <Form noValidate onSubmit={this.CreateProduct}>
                <Form.Group className="mb-3" controlId="formName">
                    <Form.Label>Name</Form.Label>
                    <Form.Control type="text" placeholder="Name" onChange={this.handleChange} value={this.state.name}/>
                </Form.Group>

                <Form.Group className="mb-3" controlId="formProductNumber">
                    <Form.Label>Product Number</Form.Label>
                    <Form.Control type="text" placeholder="Product Number" onChange={this.handleChange} value={this.state.productName}/>
                </Form.Group>

                <Form.Group className="mb-3" controlId="formPrice">
                    <Form.Label>Price</Form.Label>
                    <Form.Control type="text" placeholder="Price" onChange={this.handleChange} value={this.state.price}/>
                </Form.Group>                
                <Button variant="primary" type="submit" onSubmit={this.CreateProduct}>
                    Submit
                    </Button>
                </Form>
                </div>
            )
    }
}
