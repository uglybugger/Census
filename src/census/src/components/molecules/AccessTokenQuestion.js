import React, { Component } from "react";
import Question from './Question'
import PropTypes from 'prop-types';

class AccessTokenQuestion extends Component {
    constructor(props) {
        super(props);

        this.validate = this.validate.bind(this);
    }

    validate(value) {
        if (!value) return {validationState: "error", message: "You must input the access token you were sent via snail mail."};
        return { validationState: "success", message: null };
    }

    render() {
        return (
            <Question
                fieldName="accessToken"
                question="Please enter the access token you would have received via snail mail."
                inputType="text"
                placeholderText="f00d-f00d-f00d-f00d"
                answer={this.props.answer}
                validate={this.validate}
                onAnswerChanged={this.props.onAnswerChanged}
                isReadOnly={false}
            />
        );
    }
}

AccessTokenQuestion.propTypes = {
    onAnswerChanged: PropTypes.func.isRequired,
    answer: PropTypes.oneOfType([PropTypes.string, PropTypes.number, PropTypes.bool])
};


export default AccessTokenQuestion;