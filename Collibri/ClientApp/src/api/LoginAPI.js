import axios, {AxiosError} from "axios";

export const loginUser = async (loginData) => {
  try {
    const response = await axios.post('/v1/login', loginData);
    
    return response.data;
  } catch (err) {
    return err.response.status;
  }
}