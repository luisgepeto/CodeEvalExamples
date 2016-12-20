import System.Environment (getArgs)
import Data.Char

main = do
    [inpFile] <- getArgs    
    input <- readFile inpFile    
    mapM_ putStrLn $ map swapCases $ lines input

swapCases :: String -> String
swapCases  = reverse . foldl (\acc c -> swapCase c:acc) []

swapCase :: Char -> Char 
swapCase character
    | isUpper character = toLower character
    | isLower character = toUpper character
    | otherwise = character