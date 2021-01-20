import React, { Component } from 'react'
import MachinesList from './MachinesList'
import MachinesDetails from './MachinesDetails'
import '../styles/machinesMain.scss'

export default class MachinesMain extends Component {
    constructor() {
        super();
    }

    render() {
        return (
            <div className="container">
                <div className="div-list">
                    <MachinesList />
                </div>
                <div classNAME="div-details">
                    <MachinesDetails />
                </div>
            </div>
        )
    }
}