import axios from "axios"

const hostBack = import.meta.env.VITE_HOST_BACK

export const useGet = async(endpoint) => {
    try {
        const response = await axios.post(`${hostBack}/${endpoint}`)
        return response
    } catch (e) {
        console.error(e)
        return e
    }
}

export const usePost = async(route, data) => {
    try {
        const response = await axios.post(`${hostBack}/${route}`, data)
        return response.data
    } catch (e) {
        console.error(e)
        return e
    }
}

export const usePatch = async(route, data) => {
    try {
        const response = await axios.patch(`${hostBack}/${route}`, data)
        return response.data
    } catch (e) {
        console.error(e)
        return e
    }
}
