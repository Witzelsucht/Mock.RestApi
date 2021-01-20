import React, {Component} from 'react'
import {Spinner} from 'reactstrap'
import Customer from './Customer'
const axios = require('axios').default;
const API_URL = "http://localhost:5000/api/"

export default class MachinesList extends Component{
    constructor()
    {
        super();
        this.state = { customers: [], machines: [], customersLoaded: false, machinesLoaded: false }
    }

    componentDidMount(){
        this.loadCustomers();
        this.loadMachines();
    }

    loadCustomers(){
        axios.get(API_URL + "customers")
        .then(function(response){
            this.setState({customers: response.data, customersLoaded: true})
        })
        .catch(function(error){
            console.log(error)
        })
    }

    loadMachines(){
        axios.get(API_URL + "machines")
        .then(function(response){
            this.setState({machines: response.data, machinesLoaded: true})
        })
        .catch(function(error){
            console.log(error)
        })
    }

    render(){
        let customers = this.state.customers.map((c) =>{
            let customerMachines = this.state.machines.filter((m) => m.customerId === c.id);
            return {
                ...c,
                machines: customerMachines
            }
        });

        return(
            this.state.customersLoaded && this.state.machinesLoaded ? <Spinner/> :
            customers.map((c) => <Customer key={c.id} customer={c}/>)
        )
    }
}