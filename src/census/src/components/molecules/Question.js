import React, { Component } from 'react'
import { ControlLabel, FormGroup, FormControl, HelpBlock } from 'react-bootstrap';
import PropTypes from 'prop-types';
import { observer } from 'mobx-react';
import { compose } from 'recompose';
import './Question.css';

class Question extends Component {
    constructor(props) {
        super(props);

        this.state = {
            answer: props.answer,
            validation: {
                validationState: null,
                message: null
            }
        }

        this.handleChange = this.handleChange.bind(this);
    }

    handleChange(e) {
        var answer = e.target.value;
        var validation = this.props.validate(answer);

        this.setState({
            answer: answer,
            validation: validation
        });

        this.props.onAnswerChanged(this.props.fieldName, answer);
    }

    render() {
        return (
            <div className="row">
                <div className="col-sm-12">
                    <FormGroup
                        controlId={this.props.fieldName}
                        validationState={this.state.validation.validationState}
                    >
                        <ControlLabel>{this.props.question}</ControlLabel>
                        <FormControl type={this.props.inputType} value={this.props.answer} placeholder={this.props.placeholder} readOnly={this.props.isReadOnly} onChange={this.handleChange} />
                        <FormControl.Feedback />
                        <HelpBlock>{this.state.validation.message}</HelpBlock>
                    </FormGroup>
                </div>
                {/* {JSON.stringify(this.state)} */}
            </div>
        );
    }
}

Question.propTypes = {
    fieldName: PropTypes.string.isRequired,
    placeholderText: PropTypes.string.isRequired,
    inputType: PropTypes.string.isRequired,
    onAnswerChanged: PropTypes.func.isRequired,
    validate: PropTypes.func.isRequired,
    answer: PropTypes.oneOfType([PropTypes.string, PropTypes.number, PropTypes.bool]),
    isReadOnly: PropTypes.bool.isRequired
};

export default compose(observer)(Question);