import * as actionType from './actionType'
export const getAllRecord = (param)=>{
    return {
        type:actionType.ACTIONTYPES.FETCH_ALL_DATA,
        payload:param
    }
}
export const getPostedRecord = (param)=>{
    return {
        type:actionType.ACTIONTYPES.FETCH_ALL_POSTED,
        payload:param
    }
}

