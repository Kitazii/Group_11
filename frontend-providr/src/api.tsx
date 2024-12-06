import { Business } from "./business"

export {
    
}

export const getBuisnessProfile = async (query: string) => {
    try{
        const data = await axios.get<Business[]>(
        'https://providr.com/api/profile/${query}?apikey=${process.env.REACT_APP_API_KEY}'
        )
        return data
    } catch (error: any) {
        console.log("error message from API: ", error.message);
    }
};