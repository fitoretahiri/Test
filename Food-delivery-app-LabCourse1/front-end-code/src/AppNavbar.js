import { Link } from "react-router-dom";

const AppNavbar = (props) => {
  const logout = async () => {
    await fetch(process.env.REACT_APP_API+'authmanagement/logout',{
        method:'POST',
        headers:{
            'Accept':'application/json',
            'Content-Type':'application/json'
        },
        credentials: 'include'
    });

    props.setName('');
  }

    let menu;

  if (props.name === '' || props.name === undefined) {
    menu = (
      <div>
        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
          <li className="nav-item">
            <Link to="/" className="nav-link" >
              Login
            </Link>
          </li>
          <li className="nav-item">
            <Link to="/klientiRegister" className="nav-link" >
              Register
            </Link>
          </li>
        </ul>
      </div>
    )
  } else {
    menu = (
      <div>
        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
          <li className="nav-item">
            <Link to="/" className="nav-link" onClick={logout}>
              Logout
            </Link>
          </li>
        </ul>
      </div>
    )
  }

  return (
    <nav class="navbar navbar-expand-lg navbar-light bg-light">
      <div class="container-fluid">
        <Link to="/" class="navbar-brand text-primary" >
          ckapohajna
        </Link>
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarSupportedContent"
          aria-controls="navbarSupportedContent"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav me-auto mb-2 mb-lg-0"></ul>
          {menu}
        </div>
      </div>
    </nav>
  )
}

export default AppNavbar
