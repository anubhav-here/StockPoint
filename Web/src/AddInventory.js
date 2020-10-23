import React, { Component } from 'react'
import Button from '@material-ui/core/Button';
import { Container, TextField } from '@material-ui/core';
const axios = require('axios')
 


export default class AddInventory extends Component {

    constructor(props){
        super(props);

        this.state = {
            formOpen: false,
            invoice_id:'',
            category:'electronix',
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
            invoice_id:'',
            category:'electronix',
            item_name:null,
            item_model:null,
            quantity:null,
            price_per_unit:null

            }
        )
    }

    handleSubmit() {
        console.log(this.state.invoice_id)
        console.log(this.state.category)
        console.log(this.state.item_name)
        console.log(this.state.item_model)
        console.log(this.state.quantity)
        console.log(this.state.price_per_unit)
        axios.post('https:sample-endpoint.com/add', {
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


        <select onChange={(e)=>{this.setState({category:e.target.value})}} name="category" id="category">
            <option value="electronix">electronix</option>
            <option value="stationary">stationary</option>
            <option value="furniture">furniture</option>
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

// const Child = () => (
//     <div >
//         <form noValidate autoComplete="off">
//         <TextField id="invoice_id" label="Invoice ID" variant="outlined" /><br/>


//         <select name="cars" id="cars">
//             <option value="volvo">Volvo</option>
//             <option value="saab">Saab</option>
//             <option value="mercedes">Mercedes</option>
//             <option value="audi">Audi</option>
//         </select>
//         <br/>


//         <TextField id="item_name" label="Item Name" variant="outlined" /><br/>
//         <TextField id="item_model" label="Item Model" variant="outlined" /><br/>
//         <TextField id="quantity" label="Quantity" variant="outlined" /><br/>
//         <TextField id="price_per_unit" label="Per Price Unit" variant="outlined" />

//         <Button variant="contained" onClick={this.handleSubmit.bind(this)} color="secondary">
//                     Add
//         </Button>
//         </form>
//       </div>
//     )
