import Quote from "./components/Quote";
import "./styles.css";

export default function App() {
  return (
    <div className="App">
      <Quote
        text='"I always wanted to be somebody, but now I realize I should have been more specific."'
        author="Lily Tomlin"
      />
    </div>
  );
}
