import { combineReducers } from 'redux';
import GuestListReducer from './reducers/guestList.reducer';


export default combineReducers({
    guestList: GuestListReducer,
});
