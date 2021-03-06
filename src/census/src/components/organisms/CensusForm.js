﻿import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Button } from 'react-bootstrap';
import uuid from 'uuid';
import { Logger } from 'structured-log';
import AccessTokenQuestion from '../molecules/AccessTokenQuestion';
import LegalNameQuestion from '../molecules/LegalNameQuestion';
import BaristaNameQuestion from '../molecules/BaristaNameQuestion';
import GearInchesQuestion from '../molecules/GearInchesQuestion';
import BeardLengthQuestion from '../molecules/BeardLengthQuestion';
import BeerBitternessQuestion from '../molecules/BeerBitternessQuestion';
import FavouriteBandQuestion from '../molecules/FavouriteBandQuestion';

class CensusForm extends Component {

    constructor(props) {
        super(props);

        this.state = {
            isLoading: false,
            submission: {
                id: uuid(),
                accessToken: undefined,
                legalName: undefined,
                baristaName: undefined,
                beardLength: undefined,
                gearInches: undefined,
                beerBitterness: undefined,
                favouriteBand: "You've never heard of them."
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
        if (this.state.isLoading) return false;
        if (!this.state.submission.id) return false;
        if (!this.state.submission.accessToken) return false;
        if (!this.state.submission.legalName) return false;
        if (!this.state.submission.baristaName) return false;
        if (!this.state.submission.beardLength) return false;
        if (!this.state.submission.gearInches) return false;
        if (!this.state.submission.beerBitterness) return false;
        if (!this.state.submission.favouriteBand) return false;

        return true;
    }

    async handleSubmit(e) {
        if (!this.canSubmit()) return;

        try {
            this.setState({ isLoading: true });
            await this.props.submit(this.state.submission);
        } catch (ex) {
            this.props.logger.error(ex);
            alert("Your census form could not be lodged right now. Please try again or come back later.")
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

                    <LegalNameQuestion
                        answer={this.state.submission.legalName}
                        onAnswerChanged={this.handleAnswerChanged}
                    />

                    <BaristaNameQuestion
                        answer={this.state.submission.baristaName}
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

                    <BeerBitternessQuestion
                        answer={this.state.submission.beerBitterness}
                        onAnswerChanged={this.handleAnswerChanged}
                    />

                    <FavouriteBandQuestion
                        answer={this.state.submission.favouriteBand}
                        onAnswerChanged={this.handleAnswerChanged}
                    />

                    <div className="action-buttons">
                        <Button bsStyle="primary" onClick={this.canSubmit() ? this.handleSubmit : null} disabled={!this.canSubmit()}>Submit my census.</Button>
                    </div>
                </form>
                <div>
                    {/* {JSON.stringify(this.state)} */}
                </div>
            </div>
        );
    }
}

CensusForm.propTypes = {
    submit: PropTypes.func.isRequired,
    logger: PropTypes.instanceOf(Logger).isRequired
};

export default CensusForm;