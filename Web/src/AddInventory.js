import React, { Component } from 'react'
import Button from '@material-ui/core/Button';
import { Container, TextField } from '@material-ui/core';
const axios = require('axios')
 


export default class AddInventory extends Component {

    constructor(props){
        super(props);

        this.state = {
            formOpen: false,
            invoice_id:null,
            category:1,
            item_name:null,
            item_model:null,
            quantity:null,
            price_per_unit:null

        }

    }

    toggleButton() {
        this.setState({
            formOpen: !this.state.formOpen
        });     
    }
    resetAllFields(){
        this.setState({
            formOpen: false,
            invoice_id:null,
            category: 1,
            item_name:null,
            item_model:null,
            quantity:null,
            price_per_unit:null,
            category_options:['electronics','furniture','books']

            }
        )
    }

    handleSubmit() {
        if (!/^\d+$/.test(this.state.invoice_id))
        {
            alert('Invoice ID must be an integer!')
            return;
        }
        console.log(this.state.category)
        console.log(this.state.item_name)
        console.log(this.state.item_model)
        if (!/^\d+$/.test(this.state.quantity))
        {
            alert('Quantity must be an integer!')
            return;
        }
        if (!/^\d+$/.test(this.state.price_per_unit))
        {
            alert('Price per unit must be an integer!')
            return;
        }
        axios.post('https://stockpointtest.azurewebsites.net.com/add', {
            "invoice_id": Number(this.state.invoice_id),
            "category_id": Number(this.state.category),
            "item_name": this.state.item_name,
            "item_model": this.state.item_model,
            "quantity": Number(this.state.quantity),
            "price_per_unit": Number(this.state.price_per_unit),
            "date_of_purchase": this.state.date_of_purchase
      })
      .then(function (response) {
        console.log(response);
      })
        this.toggleButton()
        this.resetAllFields()
    }

    addInventoryForm(){
        return(
            <div >
        <form noValidate autoComplete="off">
        <TextField id="invoice_id" label="Invoice ID" onChange={(e)=>{this.setState({invoice_id:e.target.value})} } value={this.state.invoice_id} variant="outlined" /><br/>

        <label>Category:</label>
        <select onChange={(e)=>{this.setState({category:e.target.value})}} name="category" id="category">
            <option value={1}>electronics</option>
            <option value={2}>furniture</option>
            <option value={3}>books</option>

        </select>
        <br/>


        <TextField id="item_name" label="Item Name" onChange={(e)=>{this.setState({item_name:e.target.value})} } value={this.state.item_name} variant="outlined" /><br/>
        <TextField id="item_model" label="Item Model" onChange={(e)=>{this.setState({item_model:e.target.value})} } value={this.state.item_model}  variant="outlined" /><br/>
        <TextField id="quantity" label="Quantity" onChange={(e)=>{this.setState({quantity:e.target.value})} } value={this.state.quantity} variant="outlined" /><br/>
        <TextField id="price_per_unit" label="Per Price Unit" onChange={(e)=>{this.setState({price_per_unit:e.target.value})} } value={this.state.price_per_unit} variant="outlined" />
        <TextField id="date_of_purchase" label="Date of Purchase" onChange={(e)=>{this.setState({date_of_purchase:e.target.value})} } value={this.state.date_of_purchase} variant="outlined" />

            
        <Button variant="contained" onClick={this.handleSubmit.bind(this)} color="secondary">
                    Add
        </Button>
        </form>
      </div>
        );

    }

    render() {
        return (
            <Container maxWidth="sm">
                <div>
                    <Button variant="contained" onClick={this.toggleButton.bind(this)} color="primary">
                    Add
                    </Button>
                    {this.state.formOpen && this.addInventoryForm()}
                </div>
            </Container>

        )
    }

    
}