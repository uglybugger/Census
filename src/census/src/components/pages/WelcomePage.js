import React from 'react';
import { Grid, Row, Col, Image, Jumbotron, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import logo from '../../logo.png';
import Page from './Page';

class WelcomePage extends Page {
    render() {
        return (
            <div>
                <Jumbotron style={{"background-color":"#ffa500"}}>
                    <Grid>
                        <Row>
                            <Col sm={8} style={{ "text-align": "center" }}>
                                <h1>The Great Hipster Census of 2018</h1>
                                <p>Trolling hipsters since <em>before</em> it was cool.</p>
                            </Col>
                            <Col sm={4}>
                                <Image src={logo} responsive />
                            </Col>
                        </Row>
                    </Grid>
                </Jumbotron>

                <div className="action-buttons">
                    <p>
                        <Link to="data-entry"><Button bsStyle="primary">I grudgingly accept my civic duty.</Button></Link>
                    </p>
                </div>
            </div>
        );
    }
}

WelcomePage.propTypes = {
};

export default WelcomePage;