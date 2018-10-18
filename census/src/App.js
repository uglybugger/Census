import React, { Component } from 'react';
import './App.css';
import { Grid, Row, Col, Image, Jumbotron } from 'react-bootstrap';
import CensusForm from './components/censusForm/CensusForm.js'
import logo from './logo.png'   // https://pixabay.com/p-294173/?no_redirect

class App extends Component {
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
                        <CensusForm />
                    </Col>
                </Row>

            </Grid>
        );
    }
}

export default App;
