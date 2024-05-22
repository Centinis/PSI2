import axios from 'axios';

export const createMember = async (newMember, invitationCode) => {
  try {
    const response = await axios.post(`/v1/member?code=${invitationCode}`, newMember); 
    console.log(response.data);
    
    return response.data;
  } catch (err) {
    console.log(err);
    
    return err.response.status;
  }
}

export const deleteMember = async (roomId, username) => {
  try {
    const response = await axios.delete(`/v1/member?roomId=${roomId}&username=${username}`);
    console.log(response.data);

    return response.data;
  } catch (err) {
    console.log(err);

    return err.response.status;
  }
}