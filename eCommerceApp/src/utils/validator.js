//#region AI Generated
export const validateEmail = (email) => {
    // Validate email format
    return /^[a-zA-Z0-9._+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/.test(email);
};

export const validatePassword = (password) => {
    // Validate password: 8+ chars w/ upper, lower, digit
    return /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$/.test(password);
};
//#endregion
