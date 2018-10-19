import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import uuid from 'uuid';
import AccessTokenQuestion from '../molecules/AccessTokenQuestion';
import GearInchesQuestion from '../molecules/GearInchesQuestion';
import BeardLengthQuestion from '../molecules/BeardLengthQuestion';

class CensusForm extends Component {

    constructor(props) {
        super(props);

        this.state = {
            isLoading: false,
            submission: {
                id: uuid(),
                accessToken: '13a7-7f24-0000-0009',
                beardLength: 0,
                gearInches: 120
            }
        };

        this.handleAnswerChanged = this.handleAnswerChanged.bind(this);
        this.canSubmit = this.canSubmit.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleAnswerChanged(key, value) {
        var submission = Object.assign(this.state.submission, { [key]: value });

        this.setState({
            submission: submission
        });
    }

    canSubmit() {
        return !this.state.isLoading;
    }

    async handleSubmit(e) {
        try {
            this.setState({ isLoading: true });
            await this.props.submit(this.state.submission);
        } finally {
            this.setState({ isLoading: false });
        }
    }

    render() {
        return (
            <div>
                <form>
                    <AccessTokenQuestion
                        answer={this.state.submission.accessToken}
                        onAnswerChanged={this.handleAnswerChanged}
                    />

                    <BeardLengthQuestion
                        answer={this.state.submission.beardLength}
                        onAnswerChanged={this.handleAnswerChanged}
                    />

                    <GearInchesQuestion
                        answer={this.state.submission.gearInches}
                        onAnswerChanged={this.handleAnswerChanged}
                    />

                    <Button bsStyle="primary" onClick={this.canSubmit() ? this.handleSubmit : null} disabled={!this.canSubmit()}>Submit my census</Button>
                </form>
                <div>
                    {JSON.stringify(this.state)}
                </div>
            </div>
        );
    }
}

CensusForm.propTypes = {
    submit: PropTypes.func.isRequired
};

export default CensusForm;