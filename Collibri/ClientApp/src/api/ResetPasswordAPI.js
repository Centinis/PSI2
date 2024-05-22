import axios from "axios";

export const sendEmail = async (email) => {
    try {
        const response = await axios.post('/v1/resetPassword/sendEmail', email);
        return response.data;
    } catch (err) {
        return err.response.status;
    }
}

export const resetPassword = async (resetPasswordData) => {
    try {
        const response = await axios.post('/v1/resetPassword/reset', resetPasswordData);
        return response.data;
    } catch (err) {
        throw err.response.status;
    }
}