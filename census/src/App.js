import React, { Component } from 'react';
import './App.css';
import CensusForm from './components/censusForm/CensusForm.js'

class App extends Component {
    render() {
        return (
            <div className="App">
                <header className="App-header">
                    Hipster Census 2018
        </header>
                <CensusForm />
            </div>
        );
    }
}

export default App;
