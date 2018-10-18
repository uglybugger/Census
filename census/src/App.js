import React, { Component } from 'react';
import PropTypes from 'prop-types';
import './App.css';

import logo from './logo.png'   // https://pixabay.com/p-294173/?no_redirect
import { Grid, Row, Col, Image, Jumbotron } from 'react-bootstrap';
import CensusForm from './components/censusForm/CensusForm.js'

import ApiClient from './services/ApiClient';
import SubmitCensusCommand from './services/SubmitCensusCommand'

class App extends Component {

    constructor(props) {
        super(props);

        this.submit = this.submit.bind(this);
    }

    async submit(census) {
        var command = new SubmitCensusCommand(census);
        await this.props.apiClient.send(command);
    }

    render() {
        return (
            <Grid>
                <Row>
                    <Col>
                    </Col>
                    <Col>
                        <Jumbotron>
                            <Grid>
                                <Row>
                                    <Col sm={8}>
                                        <h1>Hipster Census 2018</h1>
                                        <p>Welcome to the Great Hipster Census of 2018.</p>
                                        <p>Of course, you knew about it <em>before</em> it was cool.</p>
                                    </Col>
                                    <Col sm={4}>
                                        <Image src={logo} responsive />
                                    </Col>
                                </Row>
                            </Grid>
                        </Jumbotron>
                    </Col>
                    <Col>
                    </Col>
                </Row>

                <Row>
                    <Col>
                    </Col>
                    <Col>
                        <CensusForm submit={this.submit} />
                    </Col>
                </Row>

            </Grid>
        );
    }
}

App.propTypes = {
    apiClient: PropTypes.instanceOf(ApiClient).isRequired
};

export default App;
