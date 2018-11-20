import React, { Component } from "react";
import Question from './Question'
import PropTypes from 'prop-types';

// https://www.thebrewenthusiast.com/ibus/
class BeerBitternessQuestion extends Component {
    constructor(props) {
        super(props);

        this.validate = this.validate.bind(this);
    }

    validate(value) {
        if (value < 5) return { validationState: "error", message: "That's water. Not beer. Be serious." };
        if (value > 120) return { validationState: "error", message: "While that IBU value is theoretically possible, we don't believe you." };
        return { validationState: "success", message: null };
    }

    render() {
        return (
            <Question
                fieldName="beerBitterness"
                question="What was the IBU rating of your last batch of home-brew?"
                inputType="number"
                placeholderText="What was the IBU rating of your last batch of home-brew?"
                answer={this.props.answer}
                validate={this.validate}
                onAnswerChanged={this.props.onAnswerChanged}
            />
        );
    }
}

BeerBitternessQuestion.propTypes = {
    onAnswerChanged: PropTypes.func.isRequired,
    answer: PropTypes.oneOfType([PropTypes.string, PropTypes.number, PropTypes.bool])
};


export default BeerBitternessQuestion;