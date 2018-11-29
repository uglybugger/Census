import React, { Component } from "react";
import Question from './Question'
import PropTypes from 'prop-types';

class FavouriteBandQuestion extends Component {
    constructor(props) {
        super(props);

        this.validate = this.validate.bind(this);
    }

    validate(value) {
        if (!value) return {validationState: "error", message: "Hipsters listen to music."};
        return { validationState: "success", message: null };
    }

    render() {
        return (
            <Question
                fieldName="legalName"
                question="What is the name of your favourite band?"
                inputType="text"
                placeholderText="You've never heard of them."
                answer={this.props.answer}
                validate={this.validate}
                onAnswerChanged={this.props.onAnswerChanged}
                isReadOnly={false}
            />
        );
    }
}

FavouriteBandQuestion.propTypes = {
    onAnswerChanged: PropTypes.func.isRequired,
    answer: PropTypes.oneOfType([PropTypes.string, PropTypes.number, PropTypes.bool])
};


export default FavouriteBandQuestion;