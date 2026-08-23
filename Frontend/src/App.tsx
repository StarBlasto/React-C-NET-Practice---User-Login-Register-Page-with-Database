import {useState} from 'react';
import {BrowserRouter, Route, Routes} from 'react-router-dom'

// User Info
interface UserAuth {
  username: string;
  password: string;
}

// Response
interface Response {
  message: string;
  status: boolean;
}

export default function App() {

  // variables
  const [username, setUsername] = useState<string>("");
  const [password, setPassowrd] = useState<string>("");

  // ---- Functions
  const loginFunction = () => {
    
  }

  const signupFunction = () => {

  }

  // returns page
  return (
    <div>
      <BrowserRouter>
        <Routes>
          <Route path="/login" element = {
            <>
            <h1>Login Page</h1>
            <form>
              <input type="email" placeholder="Email"/>
              <input type="password" placeholder="Password"/>
              <button onClick={loginFunction}>Login</button>
            </form>
            </>
          }/>

          <Route path="/signup" element = {
            <>
            <h1>Sign Up Page</h1>
            <form>
              <input type="email" placeholder="Email"/>
              <input type="password" placeholder="Password"/>
              <button onClick={signupFunction}>Sign Up</button>
            </form>
            </>
          }/>

          <Route path="/home" element = {
            <>
              <h1>Home Page</h1>
              <h2>{username}</h2>
            </>
          }/>

        </Routes>
      </BrowserRouter>
    </div>
  )
}