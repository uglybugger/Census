import React, { Component } from "react";
import Question from './Question'
import PropTypes from 'prop-types';

class GearInchesQuestion extends Component {
    constructor(props) {
        super(props);

        this.validate = this.validate.bind(this);
    }

    validate(value) {
        if (value < 100) return { validationState: "error", message: "You must run at least 100 gear-inches." };
        if (value > 200) return { validationState: "error", message: "We do not believe that you run more than 200 gear-inches." };
        return { validationState: "success", message: null };
    }

    render() {
        return (
            <Question
                fieldName="gearInches"
                question="How many gear-inches does your fixie run?"
                inputType="number"
                placeholderText="How many gear-inches does your fixie run?"
                answer={this.props.answer}
                validate={this.validate}
                onAnswerChanged={this.props.onAnswerChanged}
                isReadOnly={false}
            />
        );
    }
}

GearInchesQuestion.propTypes = {
    onAnswerChanged: PropTypes.func.isRequired,
    answer: PropTypes.oneOfType([PropTypes.string, PropTypes.number, PropTypes.bool])
};


export default GearInchesQuestion;