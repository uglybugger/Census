import React, { Component } from "react";
import Question from './Question'
import PropTypes from 'prop-types';

class LegalNameQuestion extends Component {
    constructor(props) {
        super(props);

        this.validate = this.validate.bind(this);
    }

    validate(value) {
        if (!value) return {validationState: "error", message: "You must have a name. Seriously."};
        return { validationState: "success", message: null };
    }

    render() {
        return (
            <Question
                fieldName="legalName"
                question="What is your legal name?"
                inputType="text"
                placeholderText="Juan Antonio Andreas Smith-Jones III"
                answer={this.props.answer}
                validate={this.validate}
                onAnswerChanged={this.props.onAnswerChanged}
                isReadOnly={false}
            />
        );
    }
}

LegalNameQuestion.propTypes = {
    onAnswerChanged: PropTypes.func.isRequired,
    answer: PropTypes.oneOfType([PropTypes.string, PropTypes.number, PropTypes.bool])
};


export default LegalNameQuestion;