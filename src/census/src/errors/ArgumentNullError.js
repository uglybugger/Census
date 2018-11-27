class ArgumentNullError extends Error {
    constructor(argumentName) {
        super(`Argument {argumentName} was null`);

        this.argumentName = argumentName;
    }
}

export default ArgumentNullError;
