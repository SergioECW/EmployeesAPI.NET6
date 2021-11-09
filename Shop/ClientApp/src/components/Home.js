import React, { Component } from 'react';
import { Button, Table } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import { EditProduct } from './EditProduct';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props){
    super(props);
        this.state = { products: [], loading: true };
        this.deleteProducts = this.deleteProducts.bind(this);
    }

    deleteProducts(e, id) {
        e.preventDefault();
        fetch('/DeleteProduct/' + id, {
            method: 'DELETE',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            }
        })
            .then(res => res.json())
            .then((result) => {
                alert(result);
                this.refreshList();
            }, (error) => {
                alert('Failed');
            });
    }

    componentDidMount() {
        this.getProducts();
    }
    
  static renderProducts (products) {
    return (
      <div>
        <h1>Products</h1>
            <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>Product Number</th>
                        <th>Product</th>
                        <th>Price</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    { products.map(products =>
                        <tr key={products.id}>
                            <td>{products.name}</td>
                            <td>{products.productNumber}</td>
                            <td>{products.price}</td>
                            <td>
                                <Link to={`/edit-product/${products.id}`}>
                                    <Button variant="success" onClick={(e) => { this.EditData(products) }}>Edit</Button>
                                </Link>
                                <br></br>
                                <Button variant="danger" onClick={(e) => { this.deleteProducts(e, products.id) }}>Delete</Button>
                            </td>
                        </tr>
                        )}                    
                </tbody>
            </Table>
            <br>
            </br>
            <Link to={`/product`}>
                <Button variant="success">Create Product</Button>
            </Link>
      </div>
    );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading</em></p> : Home.renderProducts(this.state.products);

        return (
            <div>
                {contents}
            </div>
        );
    }

    async getProducts() {
        const response = await fetch('/products');
        const data = await response.json();
        this.setState({ products: data, loading: false });
    }

    
}