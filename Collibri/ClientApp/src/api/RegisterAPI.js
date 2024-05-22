import axios from 'axios';
export const registerUser = async (userData) => {
  try {
    const response = await axios.post('/v1/register', userData);
    console.log(response.data);
    
    return response.data;
  } catch (err) {
    console.log(err);
  }
}