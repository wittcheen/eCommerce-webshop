import ky from 'ky';

export const api = ky.create({
    prefix: "http://localhost:5000/api",
    credentials: "include"
});
