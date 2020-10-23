import React from 'react';
import MUIDataTable from 'mui-datatables';
import axios from 'axios';
       import {
         FormGroup,
         FormLabel,
         Checkbox,
         FormControlLabel,
         TextField,
       } from '@material-ui/core';
       
       class Filter_new extends React.Component {
       
         state = {
           data: [],
           DateFilterChecked: false
         }  
        
         componentDidMount(){
           axios.get('https://stockpoint.azurewebsites.net/api/retrieve/all').then(response=>{
           const data=response.data;
           this.setState({data});
           })
           }
       
         render() {
           //columns: ["id","invoice_id","category_id","item_name","item_model","quantity","price_per_unit","date_of_purchase"]
           const columns = [
             {
               name: 'id',
               options: {filter: false}
             },
             {
               name: 'invoice_id',
               options: {
                 filter: true,
                 filterType: 'textField'
               }
             },
             {
               name: 'category_name',
               options: {
                 filter: true,
                 filterType: 'dropdown'
               }
             }, 
             {
               name: 'item_name',
               options: {filter: false}
             },
             {
               name: 'item_model',
               options: {filter: false}
             },
             {
               name: 'quantity',
               options: {filter: false}
             },
             {
               name: 'price_per_unit',
               options: {filter: false}
             },
             
             {
               name: 'date_of_purchase',
               options: {
                 filter: true,
                 filterType: 'custom',
       
                 customFilterListOptions: {
                   render: v => {
                     if (v[0] && v[1] && this.state.DateFilterChecked) {
                       return [`Start Date: ${v[0]}`, `End Date: ${v[1]}`];
                     } else if (v[0] && v[1] && !this.state.DateFilterChecked) {
                       return `Start Date: ${v[0]}, End Date: ${v[1]}`;
                     } else if (v[0]) {
                       return `Start Date: ${v[0]}`;
                     } else if (v[1]) {
                       return `End Date: ${v[1]}`;
                     }
                     return [];
                   },
                   update: (filterList, filterPos, index) => {
                     console.log('customFilterListOnDelete: ', filterList, filterPos, index);
       
                     if (filterPos === 0) {
                       filterList[index].splice(filterPos, 1, '');
                     } else if (filterPos === 1) {
                       filterList[index].splice(filterPos, 1);
                     } else if (filterPos === -1) {
                       filterList[index] = [];
                     }
       
                     return filterList;
                   },
                 },
                 
                 filterOptions: {
                   names: [],
                   logic(date, filters) {
                     if (filters[0] && filters[1]) {
                       return date < filters[0] || date > filters[1];
                     } else if (filters[0]) {
                       return date < filters[0];
                     } else if (filters[1]) {
                       return date > filters[1];
                     }
                     return false;
                   },
                   
                   display: (filterList, onChange, index, column) => (
                     <div>
                       <FormLabel>Date</FormLabel>
                       <FormGroup row>
                         <TextField
                           label='Start-Date'
                           value={filterList[index][0] || ''}
                           onChange={event => {
                             filterList[index][0] = event.target.value;
                             onChange(filterList[index], index, column);
                           }}
                           style={{ width: '45%', marginRight: '5%' }}
                         />
                         
                         <TextField
                           label='End-Date'
                           value={filterList[index][1] || ''}
                           onChange={event => {
                             filterList[index][1] = event.target.value;
                             onChange(filterList[index], index, column);
                           }}
                           style={{ width: '45%' }}
                         />
                         <FormControlLabel
                             control={
                               <Checkbox
                                 checked={this.state.DateFilterChecked}
                                 onChange={event => this.setState({ DateFilterChecked: event.target.checked })}
                               />
                             }
                             label='Separate Values'
                             style={{ marginLeft: '0px' }}
                         />
                     
                       </FormGroup>
                     </div>
                   ),
                 },
                 
                 print: false,
               },
             },
           ];
       
           const { data } = this.state;
           const options = {
             filter: true,
             filterType: 'multiselect',
             responsive: 'standard',
             setFilterChipProps: (colIndex, colName, data) => {
               //console.log(colIndex, colName, data);
               return {
                 color: 'primary',
                 variant: 'outlined',
                 className: 'testClass123',
               };
             }
           };
           
           return (
             <MUIDataTable 
             title="Inventory"
             data={data} 
             columns={columns} 
             options={options} />
           );
         }
       }
       
       export default Filter_new;
