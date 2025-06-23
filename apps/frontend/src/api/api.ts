import axios from 'axios';

const api = axios.create({
    baseURL: process.env.REACT_APP_API_URL ?? 'http://localhost:5098',
});


export default api; 