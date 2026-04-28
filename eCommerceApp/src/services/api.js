import ky from 'ky';

export const api = ky.create({
    prefix: "http://localhost:5000/api",
    credentials: "include"
});

export const apiError = (error, map = {}) => {
    if (!error?.response) return "Network error. Please check your connection.";

    const status = error.response.status;
    if (map[status]) return map[status];

    return "An unexpected error occurred. Please try again.";
};
