import React, {Component} from 'react'

export default class Customer extends Component{
    constructor(props){
        super(props)
        this.state = {customer: this.props.customer}
    }

    render(){
        return(
            <div></div>
        )
    }
}