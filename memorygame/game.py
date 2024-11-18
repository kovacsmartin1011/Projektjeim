import pygame
import random
import time
import pygame_menu

pygame.init()

width, height = 750, 750
rows, cols = 5, 5
tile_size = width // cols

colors = {
    'black': (74, 74, 70),
    'white': (246, 245, 224),
    'blue': (0, 227, 238),
    'red': (255, 0, 0),
    'green': (83, 255, 75),
}

font = pygame.font.SysFont(None, 60)

clock = pygame.time.Clock()

programIcon = pygame.image.load('icon.png')
pygame.display.set_icon(programIcon)

screen = pygame.display.set_mode((width, height))
pygame.display.set_caption("5x5 Memória játék")

first_card = None
second_card = None
match_found = False
game_over = False

def start_the_game():
    global first_card, second_card, match_found, game_over
    print("A játék elkezdődött!")
    running = True

    start_time = pygame.time.get_ticks()
    
    while running:  
        screen.fill(colors['white'])
        events = pygame.event.get()
        
        draw_board()
        
        elapsed_time = (pygame.time.get_ticks() - start_time) // 1000
        timer_txt = font.render(str(elapsed_time), True, colors['red'])
        screen.blit(timer_txt, (350, 10))
        
        for event in events:
            if event.type == pygame.QUIT:
                running = False
            elif event.type == pygame.MOUSEBUTTONDOWN and not match_found and not game_over:
                x, y = pygame.mouse.get_pos()
                col, row = x // tile_size, y // tile_size
                
                if not revealed[row][col]:
                    if first_card is None:
                        first_card = (row, col)
                    elif second_card is None and (row, col) != first_card:
                        second_card = (row, col)
                    
                    if second_card:
                        match_found = check_match()
            if event.type == pygame.QUIT:
                pygame.quit()
                exit()
        
        if match_found:
            time.sleep(0.5)
            match_found = False
        
        game_over = check_game_over()
        if game_over:
            text = font.render("Nyertél!", True, colors['green'])
            screen.blit(text, (width // 4, height // 2))

        pygame.display.flip()
        clock.tick(30)

menu = pygame_menu.Menu("Hello", 400, 300, theme=pygame_menu.themes.THEME_DARK)
menu.add.button('Játék', start_the_game)
menu.add.button('Kilépés', pygame_menu.events.EXIT)

cards = list(range(1, 13)) * 2 + [0]
random.shuffle(cards)

board = [cards[i * cols:(i + 1) * cols] for i in range(rows)]
revealed = [[False for _ in range(cols)] for _ in range(rows)] 

def draw_board():
    for row in range(rows):
        for col in range(cols):
            card = board[row][col]
            rect = pygame.Rect(col * tile_size, row * tile_size, tile_size, tile_size)
            if revealed[row][col] or (row, col) == first_card or (row, col) == second_card:
                pygame.draw.rect(screen, colors['white'], rect)
                if card != 0:
                    text = font.render(str(card), True, colors['black'])
                    screen.blit(text, (col * tile_size + tile_size // 6, row * tile_size + tile_size // 8))
            else:
                pygame.draw.rect(screen, colors['blue'], rect)
                pygame.draw.rect(screen, colors['black'], rect, 2)

def check_match():
    global first_card, second_card, match_found
    
    if first_card and second_card:
        r1, c1 = first_card
        r2, c2 = second_card
        
        if board[r1][c1] == board[r2][c2] and board[r1][c1] != 0:
            revealed[r1][c1] = True
            revealed[r2][c2] = True
            match_found = True
        else:
            match_found = False
        
        first_card = None
        second_card = None
        return True
    return False

def check_game_over():
    for row in revealed:
        if not all(row):
            return False
    return True

while True:
    events = pygame.event.get()
    for event in events:
        if event.type == pygame.QUIT:
            pygame.quit()
            exit()
    screen.fill((0, 0, 0))
    menu.update(events)
    menu.draw(screen)
    pygame.display.flip()
    clock.tick(30)
