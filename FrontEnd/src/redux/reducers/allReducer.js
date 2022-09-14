import { combineReducers} from "redux";
import getAllRecord from "./getAllRecord";
import getPostedRecord from "./getPostedRecord";

const allReducers = combineReducers({
    allRecords:getAllRecord,
    postedRecord:getPostedRecord
});
export default allReducers;