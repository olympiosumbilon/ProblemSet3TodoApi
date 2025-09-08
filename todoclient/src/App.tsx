import { BrowserRouter as Router, Routes, Route, Link } from "react-router-dom";
import Home from "./pages/Home";
import PrivacyPolicy from "./pages/PrivacyPolicy";
import Tos from "./pages/Tos";

function App() {
  return (
    <Router>
      <div className="nav">
        <div className="nav-inner">
          <div className="brand">
            <div className="brand-badge" />
            <span>TodoClient</span>
          </div>
          <div className="nav-links">
            <Link to="/" className="nav-link">Home</Link>
            <Link to="/privacypolicy" className="nav-link">Privacy Policy</Link>
            <Link to="/tos" className="nav-link">Terms of Service</Link>
          </div>
        </div>
      </div>
      <div className="container">
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/privacypolicy" element={<PrivacyPolicy />} />
          <Route path="/tos" element={<Tos />} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;
