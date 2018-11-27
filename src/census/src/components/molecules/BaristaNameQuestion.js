import React, { Component } from "react";
import Question from './Question'
import PropTypes from 'prop-types';

class BaristaNameQuestion extends Component {
    constructor(props) {
        super(props);

        this.validate = this.validate.bind(this);
    }

    validate(value) {
        if (!value) return { validationState: "error", message: "Come on. You at least *tallk* to your barista, don't you?" };
        return { validationState: "success", message: null };
    }

    render() {
        return (
            <Question
                fieldName="baristaName"
                question="By what name does your second-favourite barista know you?"
                inputType="text"
                placeholderText="John"
                answer={this.props.answer}
                validate={this.validate}
                onAnswerChanged={this.props.onAnswerChanged}
                isReadOnly={false}
            />
        );
    }
}

BaristaNameQuestion.propTypes = {
    onAnswerChanged: PropTypes.func.isRequired,
    answer: PropTypes.oneOfType([PropTypes.string, PropTypes.number, PropTypes.bool])
};


export default BaristaNameQuestion;