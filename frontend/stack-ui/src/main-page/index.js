import './index.css';
import Header from "./header";
import { BrowserRouter as Router, Switch, Route, Link } from "react-router-dom"
import PostList from "../post/components/post-list.component";

function App() {
  return (
    <Router>
      <div className="container">
        <Header subtitle="Stack Overflow UI" />
      </div>

      <nav className="navbar navbar-expand navbar-dark bg-dark">
        <a href="/" className="navbar-brand">
          Main page
        </a>
        <div className="navbar-nav mr-auto">
          <li className="nav-item">
            <Link to={"/posts"} className="nav-link">
              Posts
            </Link>
          </li>
          <li className="nav-item">
            <Link to={"/posts/add"} className="nav-link">
              Add post
            </Link>
          </li>
        </div>
      </nav>
      <div className="container mt-3">
        <Switch>
          <Route exact path="/posts" component={PostList} />
          {/* <Route path="/students/:id" component={Student} /> */}
        </Switch>
      </div>
    </Router>
  );
}

export default App;

