import React, { Component } from "react";
import { Button } from 'react-bootstrap';
import GearInchesQuestion from '../../molecules/GearInchesQuestion'
import BeardLengthQuestion from '../../molecules/BeardLengthQuestion'

class CensusForm extends Component {

    constructor(props) {
        super(props);

        this.state = {
            submission: {
                beardLength: 0,
                gearInches: 120
            }
        };

        this.handleAnswerChanged = this.handleAnswerChanged.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleAnswerChanged(key, value) {
        var submission = Object.assign(this.state.submission, { [key]: value });

        this.setState({
            submission: submission
        });
    }

    handleSubmit(event) {

    }

    render() {
        return (
            <div className="row">
                < div className="col-sm-4" >
                </div >
                <div className="col-sm-4" >
                    <form>
                        <BeardLengthQuestion
                            answer={this.state.submission.beardLength}
                            onAnswerChanged={this.handleAnswerChanged}
                        />

                        <GearInchesQuestion
                            answer={this.state.submission.gearInches}
                            onAnswerChanged={this.handleAnswerChanged}
                        />

                        <Button bsStyle="primary">Submit my census</Button>
                    </form>
                </div >

                <div className="col-sm-4" >
                    {JSON.stringify(this.state)}
                </div>
            </div >
        );
    }
}

export default CensusForm;