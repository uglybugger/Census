import React, { Component } from "react";
import Question from './Question'
import PropTypes from 'prop-types';

class BeardLengthQuestion extends Component {
    constructor(props) {
        super(props);

        this.validate = this.validate.bind(this);
    }

    validate(value) {
        if (value <= 0) return { validationState: "error", message: "How can you be a hipster without a beard?" };
        if (value > 300) return { validationState: "error", message: "Your beard is too long. We do not believe that you have been a hipster since before it was cool." };
        return { validationState: "success", message: null };
    }

    render() {
        return (
            <Question
                fieldName="beardLength"
                question="How long (in millimetres) is your luxurious beard?"
                inputType="number"
                placeholderText="How long (in millimetres) is your luxurious beard?"
                answer={this.props.answer}
                validate={this.validate}
                onAnswerChanged={this.props.onAnswerChanged}
            />
        );
    }
}

BeardLengthQuestion.propTypes = {
    onAnswerChanged: PropTypes.func.isRequired,
    answer: PropTypes.oneOfType([PropTypes.string, PropTypes.number, PropTypes.bool])
};


export default BeardLengthQuestion;